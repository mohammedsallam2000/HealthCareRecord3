var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewlab", function (mes) {
    $("#a").append(mes);
});
connection.start();