﻿using NakaEngine.Interfaces;
using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace NakaEngine.Loaders
{
    public static class LoadableLoader
    {
        private static List<ILoadable> loadCache = new();

        public static void Load()
        {
            foreach (Type type in NakaEngine.Assembly.GetInheritedInterfaceTypes(typeof(ILoadable)))
            {
                ILoadable loadable = Activator.CreateInstance(type) as ILoadable;
                loadable.Load();

                loadCache.Add(loadable);
            }
        }

        public static void Unload()
        {
            foreach (ILoadable loadable in loadCache)
            {
                loadable.Unload();
            }

            loadCache.Clear();
        }
    }
}
