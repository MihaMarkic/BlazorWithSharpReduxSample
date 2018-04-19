const withDevTools = (typeof window !== 'undefined' && window.__REDUX_DEVTOOLS_EXTENSION__);
Blazor.registerFunction('DevToools.AreAvailable', function () {
    return withDevTools !== null;
});
Blazor.registerFunction('DevToools.Init', function (state) {
    console.log('Init for : ' + withDevTools);
    window.devTools = window.__REDUX_DEVTOOLS_EXTENSION__.connect();
    return devTools.init(state);
});
Blazor.registerFunction('DevToools.Send', function (action, state) {
    return devTools.send(action, state);
});