using System;
using System.Diagnostics;
using EngineLibrary.Core;
using EngineLibrary.Interfaces;
using EngineLibrary.Items;
using EngineLibrary.Items.Interfaces;
using EngineLibrary.Services;

namespace EngineLibrary
{
    public class Engine
    {
        private bool _isRunning;
        private bool _isModifyMode;

        private ConsoleWriter _consoleWriter;

        private readonly InfoPopup _help;
        private readonly RealtimeInfo _realtimeInfo = RealtimeInfo.GetInstance();
        private readonly IItemsHandler _itemsHandler;



        public Engine()
        {
            _itemsHandler = new ItemsHandler();
            _consoleWriter = new ConsoleWriter();
            _help = new InfoPopup(_consoleWriter.Width, _consoleWriter.Height - 1, 1, '*');
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (_help.IsVisible && keyInfo.Key != ConsoleKey.H && keyInfo.Key != ConsoleKey.Escape)
                    return;


                int scalableDeltaValue = (int)_consoleWriter.ScaleX < 1 ? 1 : (int)_consoleWriter.ScaleX;

                int keyDigit = (int)(keyInfo.Key - '0');
                if (keyDigit >= 0 && keyDigit <= 9)
                    _itemsHandler.SelectItem(keyDigit);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        _isRunning = false;
                        break;
                    case ConsoleKey.A:
                        _itemsHandler.AddItem(ConsoleHelper.ReadDigitOrDefault());
                        break;
                    case ConsoleKey.R:
                        _itemsHandler.RemoveItem();
                        break;
                    case ConsoleKey.H:
                        _help.IsVisible = !_help.IsVisible;
                        break;
                    case ConsoleKey.M:
                        _isModifyMode = !_isModifyMode;
                        break;
                    case ConsoleKey.F:
                        if (_itemsHandler.CurrentItem != null) 
                            _itemsHandler.CurrentItem.isFilled = !_itemsHandler.CurrentItem.isFilled;
                        break;
                    case ConsoleKey.Q:
                        _itemsHandler.ToggleSortByLength();
                        break;
                    case ConsoleKey.W:
                        _itemsHandler.ToggleSortByArea();
                        break;
                    case ConsoleKey.S:
                        _itemsHandler.SaveScene(ConsoleHelper.ReadDigitOrDefault());
                        break;
                    case ConsoleKey.L:
                        _itemsHandler.LoadScene(ConsoleHelper.ReadDigitOrDefault());
                        break;
                    case ConsoleKey.LeftArrow:
                        if (_isModifyMode)
                            (_itemsHandler.CurrentItem as IModifiable)?.ChangeHorizontal(-scalableDeltaValue);
                        else
                            _itemsHandler.CurrentItem?.Move(-scalableDeltaValue, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        if (_isModifyMode)
                            (_itemsHandler.CurrentItem as IModifiable)?.ChangeHorizontal(scalableDeltaValue);
                        else
                            _itemsHandler.CurrentItem?.Move(scalableDeltaValue, 0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (_isModifyMode)
                            (_itemsHandler.CurrentItem as IModifiable)?.ChangeVertical(-scalableDeltaValue);
                        else
                            _itemsHandler.CurrentItem?.Move(0, -scalableDeltaValue);
                        break;
                    case ConsoleKey.DownArrow:
                        if (_isModifyMode)
                            (_itemsHandler.CurrentItem as IModifiable)?.ChangeVertical(scalableDeltaValue);
                        else
                            _itemsHandler.CurrentItem?.Move(0, scalableDeltaValue);
                        break;
                    default:
                        break;
                }

            }
        }

        private void Update(double ellapsedTime)
        {
            // Update state (position etc) of all drawable objects

            int framerate = (int)(1 / ellapsedTime);

            _realtimeInfo.SetInfo("FPS", framerate);
            _realtimeInfo.SetInfo("Shapes count", _itemsHandler.Items.Count);
            _realtimeInfo.SetInfo("Selected shape index", _itemsHandler.Items.IndexOf(_itemsHandler.CurrentItem));
            _realtimeInfo.SetInfo("Modify mode", _isModifyMode.ToString());

        }

        private void Render()
        {
            // Scaling objects
            int width = Console.WindowWidth - 1;
            int height = Console.WindowHeight - 1;
            if (width != _consoleWriter.Width || height != _consoleWriter.Height)
            {
                _consoleWriter = new ConsoleWriter(width, height);
            }

            // Rendering scene
            for (int i = 0; i < _itemsHandler.Items.Count; i++)
                _itemsHandler.Items[i].Draw(_consoleWriter, (char)(i + '0'));


            _help.Draw(_consoleWriter);
            _realtimeInfo.Draw(_consoleWriter);

            _consoleWriter.FastFlush();
        }

        public void Start()
        {
            _isRunning = true;
            Stopwatch clock = new Stopwatch();
            int maxFramerate = 60;
            double minFrameTime = 1.0 / maxFramerate;
            clock.Start();

            while (_isRunning)
            {
                double dt = clock.ElapsedMilliseconds;
                double dtSec = dt / 1000;
                
                if(dtSec >= minFrameTime)
                {
                    clock.Restart();
                    Input();
                    Update(dtSec);
                    Render();
                }
            }
        }
    }
}
