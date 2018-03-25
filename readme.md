# Experimenting with Blazor and SharpRedux

## About

This project aims to integrate [sharp-redux](https://github.com/MihaMarkic/sharp-redux) with [Blazor](https://github.com/aspnet/Blazor). Also using [Righthand.Immutable](https://github.com/MihaMarkic/Righthand.Immutable) which plays nicely with sharp-redux.

Current work is very early experimenting. Since Blazor has problems with Task.Run (it seems) I had to remove async for sharp-redux. I did it by copying sharp-redux sources and change/comment async code.

Basically the Dispatch operation is now synchronous. As I said, early experiment. Eventually the official sharp-redux library will play well with Blazor.

## Run the sample

Clone or get sources, and run it as Blazor project (see [getting started instructions](https://blogs.msdn.microsoft.com/webdev/2018/03/22/get-started-building-net-web-apps-in-the-browser-with-blazor/)).

Current sample is as simple as it gets - incremental counter, similar to Blazor's sample.