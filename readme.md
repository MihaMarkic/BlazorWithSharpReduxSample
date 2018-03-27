# Experimenting with Blazor and SharpRedux

## About

This project aims to integrate [sharp-redux](https://github.com/MihaMarkic/sharp-redux) with [Blazor](https://github.com/aspnet/Blazor). Also using [Righthand.Immutable](https://github.com/MihaMarkic/Righthand.Immutable) which plays nicely with sharp-redux.

Current work is very early experimentation.

## Run the sample

Clone or get sources, and run it as Blazor project (see [getting started instructions](https://blogs.msdn.microsoft.com/webdev/2018/03/22/get-started-building-net-web-apps-in-the-browser-with-blazor/)).

Currently there are two sample components running with redux:
* Counter - incremental counter, similar to Blazor's sample.
* FetchData - similar to Blazor's sample, except it has a "Reload" button added

Below sample DOM the redux actions are listed.
