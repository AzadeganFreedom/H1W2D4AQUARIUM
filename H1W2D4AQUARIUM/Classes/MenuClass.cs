using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace H1W2D4AQUARIUM.Classes
{
    internal class MenuClass
    {
        public AquariumClass Aquarium;
        public FishClass Fish;
        public DataClass Data;
        public ViewModel CurrentViewModel { get; set; }

        public int HorizontalMenuItemSelected = 0;
        public int VerticalMenuItemSelected = 0;

        public bool MenuItemIsActive = false;

        public enum ViewModel
        {
            FishList,
            AddFish,
            RemoveFish,
            Data,
            AquariumList,
            AquariumDetails,
            AddAquarium,
            RemoveAquarium,
            Exit
        }

        string[] menuItems = new string[] { "Show Aquariums", "Show Fish", "Add Aquarium", "Remove Aquarium", "Add Fish", "Remove Fish", "Exit" };

        public void ShowMenu()
        {

            Console.Clear();

            Console.SetCursorPosition(3, 0);
            Console.Write("Menu |");

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (HorizontalMenuItemSelected == i && !MenuItemIsActive)
                {

                    Console.Write(" ");
                    HoverEfftect(true);
                    Console.Write(menuItems[i]);
                    HoverEfftect(false);

                    Console.Write(" |");

                }
                else if (HorizontalMenuItemSelected == i && MenuItemIsActive)
                {

                    Console.Write(" ");
                    ApplyInactiveEffect(true);
                    Console.Write(menuItems[i]);
                    ApplyInactiveEffect(false);

                    Console.Write(" |");
                }
                else
                {
                    Console.Write($" {menuItems[i]} |");
                }
            }

            Console.SetCursorPosition(0, 1);
            DrawLine();
            Console.SetCursorPosition(0, 3);

            LoadViewModel(CurrentViewModel);

        }


        public void LoadViewModel(ViewModel viewModel)
        {

            switch (viewModel)
            {
                case ViewModel.AquariumList:
                    Aquarium.ShowAquariumList();
                    return;

                case ViewModel.FishList:
                    Fish.ShowFishList();
                    return;

                case ViewModel.AddFish:
                    if (!MenuItemIsActive)
                    {
                        Fish.ShowCreateFishViewModel();
                    }
                    else if (Aquarium.AquariumList.Count > 0)
                    {
                        Fish.AddFish();
                    }
                    return;

                case ViewModel.RemoveFish:
                    Fish.ShowFishList();
                    return;

                case ViewModel.AquariumDetails:
                    Aquarium.ShowAquariumDetails(VerticalMenuItemSelected);
                    return;

                case ViewModel.AddAquarium:
                    if (!MenuItemIsActive)
                    {
                        Aquarium.ShowAddAquariumViewModel();
                    }
                    else
                    {
                        Aquarium.AddAquarium();
                    }
                    return;

                case ViewModel.RemoveAquarium:
                    Aquarium.ShowAquariumList();
                    return;

            }


        }

        public void ApplyInactiveEffect(bool apply)
        {
            if (apply)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                return;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void HoverEfftect(bool apply)
        {
            if (apply)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void DrawLine()
        {

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

        }
        public void SelectMenuItem()
        {
            ConsoleKeyInfo consoleKey;

            Console.CursorVisible = false;
            consoleKey = Console.ReadKey(true);

            switch (consoleKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (MenuItemIsActive)
                    {
                        MenuItemIsActive = false;
                    }
                    ChangeHorizontalMenuItem(-1);
                    return;

                case ConsoleKey.RightArrow:
                    if (MenuItemIsActive)
                    {
                        MenuItemIsActive = false;
                    }
                    ChangeHorizontalMenuItem(1);
                    return;

                case ConsoleKey.UpArrow:
                    ChangeVerticalMenuItem(-1, "up");
                    return;

                case ConsoleKey.DownArrow:
                    ChangeVerticalMenuItem(1, "down");
                    return;

                case ConsoleKey.Enter:
                    if (MenuItemIsActive)
                    {
                        PressEnterOnActiveMenu();
                    }

                    MenuItemIsActive = true;
                    return;

                default:
                    break;
            }


        }

        private void PressEnterOnActiveMenu()
        {
            switch (CurrentViewModel)
            {
                case ViewModel.FishList:
                    break;

                case ViewModel.RemoveFish:
                    Fish.RemoveFish(VerticalMenuItemSelected);
                    break;

                case ViewModel.AquariumList:
                    CurrentViewModel = ViewModel.AquariumDetails;
                    break;

                case ViewModel.RemoveAquarium:
                    Aquarium.RemoveAquarium(VerticalMenuItemSelected);
                    break;

                case ViewModel.Exit:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
        }

        private void ChangeVerticalMenuItem(int valueModifier, string keyInitiator)
        {
            int MenuLowerLimit = 0;
            int MenuUpperLimit = 0;

            switch (CurrentViewModel)
            {
                case ViewModel.AquariumList:
                    MenuUpperLimit = Aquarium.AquariumList.Count - 1;
                    break;

                case ViewModel.RemoveAquarium:
                    MenuUpperLimit = Aquarium.AquariumList.Count - 1;
                    break;

                case ViewModel.RemoveFish:
                    MenuUpperLimit = Fish.FishList.Count - 1;
                    break;

                case ViewModel.FishList:
                    MenuUpperLimit = Fish.FishList.Count - 1;
                    break;

                case ViewModel.AddAquarium:
                    return;

                case ViewModel.AddFish:
                    return;

                case ViewModel.AquariumDetails:
                    CurrentViewModel = ViewModel.AquariumList;
                    return;

            }

            if (valueModifier == 1 && !MenuItemIsActive)
            {
                MenuItemIsActive = true;
                return;
            }

            if (valueModifier == -1 && VerticalMenuItemSelected == MenuLowerLimit)
            {
                MenuItemIsActive = false;
                return;
            }

            if (valueModifier == 1 && VerticalMenuItemSelected == MenuUpperLimit)
            {
                return;
            }

            VerticalMenuItemSelected += valueModifier;

        }

        private void ChangeHorizontalMenuItem(int valueModifier)
        {
            if (MenuItemIsActive)
            {
                return;
            }

            if (valueModifier == -1 && HorizontalMenuItemSelected == 0)
            {
                return;
            }

            if (valueModifier == 1 && HorizontalMenuItemSelected == menuItems.Length - 1)
            {
                return;
            }

            HorizontalMenuItemSelected += valueModifier;
            SetCurrentlySelectedMenuItem();
            ShowMenu();
        }

        private void SetCurrentlySelectedMenuItem()
        {
            switch (menuItems[HorizontalMenuItemSelected])
            {
                case "Show Aquariums":
                    CurrentViewModel = ViewModel.AquariumList;
                    return;

                case "Show Fish":
                    CurrentViewModel = ViewModel.FishList;
                    return;

                case "Add Aquarium":
                    CurrentViewModel = ViewModel.AddAquarium;
                    return;

                case "Remove Aquarium":
                    CurrentViewModel = ViewModel.RemoveAquarium;
                    return;

                case "Add Fish":
                    CurrentViewModel = ViewModel.AddFish;
                    return;

                case "Remove Fish":
                    CurrentViewModel = ViewModel.RemoveFish;
                    return;

                case "Exit":
                    CurrentViewModel = ViewModel.Exit;
                    return;
            }

        }

        public bool ConfirmAction()
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey(true); // User needs to confirm that they want to delete the selected task

            switch (consoleKey.Key)
            {
                case ConsoleKey.Y:
                    return true;

                case ConsoleKey.N:
                    return false;

            }

            return false;
        }

    }
}
