var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewSergery", function () {
    location.reload();
});

connection.start();