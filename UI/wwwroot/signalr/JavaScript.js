var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewlab", function (mes) {
    location.reload();
    
});

//connection.on("aaA", function (mes) {
//    location.reload();
//});
connection.start();