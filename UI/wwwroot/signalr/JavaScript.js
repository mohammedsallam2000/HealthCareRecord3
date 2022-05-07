var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewlab", function (mes) {
    location.reload();   
});
connection.on("GetNewRadiology", function (mes) {
    location.reload();
});
connection.on("GetNewTreatment", function (mes) {
    location.reload();
});
//connection.on("newDoctor", function () {
//    location.reload();
//});

//connection.on("aaA", function (mes) {
//    location.reload();
//});
connection.start();