var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewRoom", function () {
    location.reload();
});

connection.start();