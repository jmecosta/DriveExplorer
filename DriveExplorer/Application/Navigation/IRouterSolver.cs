﻿using System;

namespace DriverExplorer.Application.Navigation {
    public interface IRouterSolver {
        string SolveRoute(object viewModel);

        string SolveRoute<T>();

        Type SolveType(string route);
    }
}