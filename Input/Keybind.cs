﻿using Microsoft.Xna.Framework.Input;
using System;

namespace NakaEngine.Input
{
    public sealed class Keybind
    {
        public Keys Key
        {
            get;
            set;
        }

        public bool IsKeyDown
        {
            get;
            set;
        }

        public bool JustPressed
        {
            get;
            set;
        }

        public bool JustReleased
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public event Action OnPress;

        public event Action OnRelease;

        public event Action OnKeyDown;

        public Keybind(Keys key)
        {
            Key = key;

            KeybindSystem.RegisterKeybind(this);
        }

        internal void Update(bool isPressed, bool wasPressed)
        {
            if (isPressed)
            {
                IsKeyDown = true;
                JustReleased = false;

                JustPressed = !wasPressed;

                OnKeyDown?.Invoke();

                if (JustPressed)
                {
                    OnPress?.Invoke();
                }
            }
            else
            {
                IsKeyDown = false;
                JustPressed = false;

                JustReleased = wasPressed;

                if (JustReleased)
                {
                    OnRelease?.Invoke();
                }
            }
        }
    }
}