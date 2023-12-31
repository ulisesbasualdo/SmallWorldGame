﻿using SmallWorld.src.Controllers;
using SmallWorld.src.Model;
using SmallWorld.src.Model.Interactable;
using SmallWorld.src.Model.Interactuable;
using SmallWorld.src.Model.Map;
using SmallWorld.src.Model.Terrain;
using SmallWorld.src.UI.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SmallWorld.src.UI.CustomForms;

namespace SmallWorld.src.UI.FormsGame
{
    public partial class FormGame : Form
    {
        EntityController entityController = EntityController.GetInstance();
        ItemController itemController = ItemController.GetInstance();
        FoodController foodController = FoodController.GetInstance();
        MapController mapController = MapController.GetInstance();
        FormController formController = FormController.GetInstance();
        GameController gameController = GameController.GetInstance();
        List<HexagonControl> hexagons = new List<HexagonControl>();
        List<Land> lands = new List<Land>();
        int indexOfSelectedHexagon;
        int playerTurn = 0;
        Entity currentPlayerEntity;
        Entity waitingPlayerEntity;
        HexagonControl selectedHexagon = null;
        private int timeGame;
        private int timeTurn;
        public FormGame()
        {
            InitializeComponent();
            lands = mapController.getLands();
            AddHexagonsToList();
            foreach (var hexagon in hexagons)
            {
                hexagon.Click += Hexagon_Click;
            }
            MapNumberLandsView();
            PaintHexagons();
            hexagon12.IsSelected = true;
            indexOfSelectedHexagon = hexagons.IndexOf(hexagon12);
            ChangeColorOfSelectedHexagonAndTheirBorderingHexagons(lands[hexagons.IndexOf(hexagon12)]);
            lblResultWar.Text = $"Jugador1: {entityController.CountEntitiesPerPlayer(1)} vs Jugador2: {entityController.CountEntitiesPerPlayer(2)}";
            FillDgvs(indexOfSelectedHexagon);
            timeGame = gameController.getGameOptions().TimeGame;
            timeTurn = gameController.getGameOptions().TimeTurn;
            SetWhichPlayerStarts();
            //rbPlayer1Turn.Checked = true; //TODO: tirar dados para ver quien empieza.
            timerGame.Start();
            timerTurn.Start();
        }
        private void SetWhichPlayerStarts()
        {
            int diceP1 = 0;
            int diceP2 = 0;
            while (diceP1 == diceP2)
            {
                diceP1 = Dice.TrowDice(6);
                diceP2 = Dice.TrowDice(6);
            }
            
            if (diceP1 > diceP2)
            {
                new CustomMessageBoxForm($"Tiramos dados para comenzar: \nJugador1: {diceP1} | Jugador2: {diceP2}. \nComienza el jugador1").ShowDialog();

                rbPlayer1Turn.Checked = true;
            }
            else if (diceP1 < diceP2)
            {
                new CustomMessageBoxForm($"Tiramos dados para comenzar: \nJugador1: {diceP1} | Jugador2: {diceP2}. \nComienza el jugador2").ShowDialog();
                rbPlayer2Turn.Checked = true;
            }
        }
        private void AddHexagonsToList()
        {
            hexagons.AddRange(new List<HexagonControl>
            {
                hexagon0, hexagon1, hexagon2, hexagon3, hexagon4, hexagon5,
                hexagon6, hexagon7, hexagon8, hexagon9, hexagon10, hexagon11,
                hexagon12, hexagon13, hexagon14, hexagon15, hexagon16, hexagon17,
                hexagon18
            });
        }
        private void FillDgvs(int selectedHexagon)
        {
            dgvFood.Rows.Clear();
            dgvItems.Rows.Clear();
            dgvP1Entities.Rows.Clear();
            dgvP2Entities.Rows.Clear();

            Land land = mapController.getLands()[selectedHexagon];

            foreach (Entity entity in land.Entities.Where(e => e.NumPlayer == 1 && e.DieStatus == false))
            {
                dgvP1Entities.Rows.Add(entity.Id, entity.Name, entity.Kingdom,
                    entity.HabitatName, entity.Diet, $"{entity.CurrentLife}/{entity.MaxLife}",
                    $"{entity.CurrentEnergy}/{entity.MaxEnergy}", entity.AttackPoints,
                    entity.DefensePoints);
            }
            foreach (Entity entity in land.Entities.Where(e => e.NumPlayer == 2 && e.DieStatus == false))
            {
                dgvP2Entities.Rows.Add(entity.Id, entity.Name, entity.Kingdom,
                    entity.HabitatName, entity.Diet, $"{entity.CurrentLife}/{entity.MaxLife}",
                    $"{entity.CurrentEnergy}/{entity.MaxEnergy}", entity.AttackPoints,
                    entity.DefensePoints);
            }

            foreach (Item item in land.Items)
            {
                dgvItems.Rows.Add(item.Id, item.StrategyNames);
            }
            foreach (Food food in land.Foods)
            {
                dgvFood.Rows.Add(food.Id, food.DietNames, food.EnergyValue);
            }
            lblResultWar.Text = $"Jugador1: {entityController.CountEntitiesPerPlayer(1)} vs Jugador2: {entityController.CountEntitiesPerPlayer(2)}";
            VerifyWinner();
        }
        private void Hexagon_Click(object sender, EventArgs e)
        {
            HexagonControl clickedHexagon = sender as HexagonControl;
            int index = hexagons.IndexOf(clickedHexagon);
            ChangeColorOfSelectedHexagonAndTheirBorderingHexagons(lands[index]);

            if (!clickedHexagon.IsSelected)
            {
                foreach (var hexagon in hexagons)
                {
                    hexagon.IsSelected = false;
                }

                clickedHexagon.IsSelected = true;
                indexOfSelectedHexagon = hexagons.IndexOf(clickedHexagon);
                FillDgvs(indexOfSelectedHexagon);
            }

        }
        private void ChangeColorOfSelectedHexagonAndTheirBorderingHexagons(Land land)
        {
            ResetHexagonBorderColor();
            hexagons[land.Id].BackColor = Color.Gold;
            hexagons[land.Id].ForeColor = Color.Black;
            for (int i = 0; i < land.BorderingLands.Count(); i++)
            {
                hexagons[land.BorderingLands[i].Id].BackColor = Color.NavajoWhite;
                hexagons[land.BorderingLands[i].Id].ForeColor = Color.Black;
            }
        }
        private void ResetHexagonBorderColor()
        {
            foreach (var hexagon in hexagons)
            {
                hexagon.BackColor = Color.Transparent; // O utiliza el color original del borde
                hexagon.ForeColor = Color.White;
            }
        }
        private void PaintHexagons()
        {
            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].BorderColor = lands[i].TerrainType.getColor();
            }
        }

        private void FormGame_Load(object sender, EventArgs e)
        {

        }

        private void btnFoodMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].HexagonText = $"{lands[i].Foods.Count}";
                hexagons[i].Invalidate();
            }
        }

        private void btnItemsMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].HexagonText = $"{lands[i].Items.Count}";
                hexagons[i].Invalidate();
            }
        }

        private void ChangeLandsInfo<GenericList>(List<GenericList> ObjectsList)
        {

            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].HexagonText = $"{lands[i].Items}"; //TODO: resolver como mostrar los diferentes modos de mapa en una sola función
            }
        }

        private void btnEntitiesMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].HexagonText = $"{lands[i].Entities.Count(entity => entity.DieStatus == false && entity.NumPlayer == 1)} vs {lands[i].Entities.Count((entity => entity.DieStatus == false && entity.NumPlayer == 2))}";
                hexagons[i].Invalidate();
            }
        }
        private void MapNumberLandsView()
        {
            for (int i = 0; i < hexagons.Count(); i++)
            {
                hexagons[i].HexagonText = $"{i}";
                hexagons[i].Invalidate();
            }
        }

        private void btnNumLandMap_Click(object sender, EventArgs e)
        {
            MapNumberLandsView();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            SetCurrentAndWaitingPlayer();
            if (dgvP1Entities.SelectedRows.Count > 0 && dgvP2Entities.SelectedRows.Count > 0)
            {
                //TODO: aca será entityCurrentPlayer y entityWaitingPlayer
                //Entity entity1 = entityController.FindEntity(Convert.ToInt32(dgvP1Entities.SelectedRows[0].Cells["IdEntity"].Value));
                //Entity entity2 = entityController.FindEntity(Convert.ToInt32(dgvP2Entities.SelectedRows[0].Cells["IdEntity2"].Value));


                try
                {
                    entityController.Attack(currentPlayerEntity, waitingPlayerEntity);
                    FillDgvs(indexOfSelectedHexagon);
                }
                catch (Exception ex)
                {
                    new CustomMessageBoxForm(ex.Message).ShowDialog();
                    FillDgvs(indexOfSelectedHexagon);
                }
            }
            else { new CustomMessageBoxForm($"Error, debe seleccionar su Entidad\n y la entidad a atacar").ShowDialog(); }
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            Item item = itemController.FindItem(Convert.ToInt32(dgvItems.SelectedRows[0].Cells[0].Value));
            SetCurrentAndWaitingPlayer();
            try
            {
                //Entity entity1 = entityController.FindEntity(Convert.ToInt32(dgvP1Entities.SelectedRows[0].Cells["IdEntity"].Value));
                item.ExecuteEffectStrategy(currentPlayerEntity);
                FillDgvs(indexOfSelectedHexagon);
            }
            catch (Exception ex)
            {
                new CustomMessageBoxForm(ex.Message).ShowDialog();
            }
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            SetCurrentAndWaitingPlayer();
            Food food = foodController.FindFood(Convert.ToInt32(dgvFood.SelectedRows[0].Cells[0].Value));
            try
            {
                entityController.Eat(currentPlayerEntity, food);
                FillDgvs(indexOfSelectedHexagon);
            }
            catch (Exception ex)
            {
                new CustomMessageBoxForm(ex.Message).ShowDialog();
            }
        }

        

        private void rbPlayer1Turn_Click(object sender, EventArgs e)
        {
        }

        private void rbPlayer2Turn_Click(object sender, EventArgs e)
        {
            
        }

        private void SetCurrentAndWaitingPlayer()
        {
            if (dgvP1Entities.SelectedRows.Count > 0 && dgvP2Entities.SelectedRows.Count > 0)
            {
                if (playerTurn == 1)
                {
                    currentPlayerEntity = entityController.FindEntity(Convert.ToInt32(dgvP1Entities.SelectedRows[0].Cells[0].Value));
                    waitingPlayerEntity = entityController.FindEntity(Convert.ToInt32(dgvP2Entities.SelectedRows[0].Cells[0].Value));
                }
                if (playerTurn == 2)
                {
                    currentPlayerEntity = entityController.FindEntity(Convert.ToInt32(dgvP2Entities.SelectedRows[0].Cells[0].Value));
                    waitingPlayerEntity = entityController.FindEntity(Convert.ToInt32(dgvP1Entities.SelectedRows[0].Cells[0].Value));
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (currentPlayerEntity != null)
            {
                new FormMove(lands[indexOfSelectedHexagon], currentPlayerEntity).ShowDialog();
                FillDgvs(indexOfSelectedHexagon);
            }
            else new CustomMessageBoxForm("asegurese de seleccionar tierra de origen y la entidad a mover").ShowDialog();
        }

        private void dgvP1Entities_SelectionChanged(object sender, EventArgs e)
        {
            SetCurrentAndWaitingPlayer();
        }

        private void dgvP2Entities_SelectionChanged(object sender, EventArgs e)
        {
            SetCurrentAndWaitingPlayer();
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            timeGame--;
            lblTimeGame.Text = TimeSpan.FromSeconds(timeGame).ToString(@"mm\:ss");

            if (timeGame <= 0)
            {
                timerGame.Stop();
                if (entityController.CountEntitiesPerPlayer(1) > entityController.CountEntitiesPerPlayer(2))
                {
                    new CustomMessageBoxForm("Ganador Jugador 1").ShowDialog();
                }
                else if (entityController.CountEntitiesPerPlayer(2) > entityController.CountEntitiesPerPlayer(1))
                {
                    new CustomMessageBoxForm("Ganador Jugador 2").ShowDialog();
                }
                else if (entityController.CountEntitiesPerPlayer(2) == entityController.CountEntitiesPerPlayer(1))
                {
                    new CustomMessageBoxForm("Hay un empate").ShowDialog();
                }
            }
        }

        private void timerTurn_Tick(object sender, EventArgs e)
        {
            timeTurn--;
            lblTimeTurn.Text = TimeSpan.FromSeconds(timeTurn).ToString(@"mm\:ss");

            if (timeTurn <= 0)
            {
                timerTurn.Stop();
                if (playerTurn == 1)
                {
                    rbPlayer2Turn.Checked = true;  //.Checked = true;
                    rbPlayer1Turn.Checked = false;
                }
                else if (playerTurn == 2)
                {
                    rbPlayer1Turn.Checked = true;
                    rbPlayer2Turn.Checked = false;
                }
                // Realiza la acción que debas al finalizar el tiempo de 2 minutos.
            }
        }
        private void rbPlayer1Turn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPlayer1Turn.Checked)
            {
                //rbPlayer2Turn.Enabled = false;
                playerTurn = 1;
                timeTurn = gameController.getGameOptions().TimeTurn;
                timerTurn.Start();
                picColorTurnP1.BackColor = Color.PaleGreen;
                picColorTurnP2.BackColor = Color.Gray;
            }
        }
        private void rbPlayer2Turn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPlayer2Turn.Checked)
            {
                //rbPlayer1Turn.Enabled = false;
                playerTurn = 2;
                timeTurn = gameController.getGameOptions().TimeTurn;
                timerTurn.Start();
                picColorTurnP1.BackColor = Color.Gray;
                picColorTurnP2.BackColor = Color.PaleGreen;
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            if (currentPlayerEntity != null)
            {
                entityController.Rest(currentPlayerEntity);
            }
            else new CustomMessageBoxForm("Debe seleccionar una entidad").ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            new CustomMessageBoxForm($"Cada jugador tiene {gameController.getGameOptions().TimeTurn} \n" +
                $"segundos para hacer lo que quiera, \n" +
                $"gana el jugador que más entidades tenga al \n" +
                $"finalizar el tiempo del juego o en caso de \n" +
                $"eliminar todas las entidades enemigas").ShowDialog();
        }
        private void VerifyWinner()
        {
            if (entityController.CountEntitiesPerPlayer(1) == 0)
            {
                new CustomMessageBoxForm("Ganador Jugador 2").ShowDialog();
            }
            if (entityController.CountEntitiesPerPlayer(2) == 0)
            {
                new CustomMessageBoxForm("Ganador Jugador 1").ShowDialog();
            }
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
