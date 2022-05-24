var x = document.getElementById("myAudio");
var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewlab", function () {

    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/LabDoctor/WaitingPage">
                                                    There are an Analysis Order
                                                    
                                                </a>
                                            </div>
                                        </li>`);
    playAudio();
    var counter1 = parseInt($('#notificationCounter').text());

    counter1 = counter1 + 1;
    $('#notificationCounter').text(counter1);
});
connection.on("GetNewTreatment", function () {

    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/Pharmacist/WaitingPage">
                                                   There are a Treatment Order
                                                    
                                                </a>
                                            </div>
                                        </li>`);
    playAudio();
    var counter1 = parseInt($('#notificationCounter').text());

    counter1 = counter1 + 1;
    $('#notificationCounter').text(counter1);
});
connection.on("GetNewRadiology", function () {

    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/RadiologyDoctor/WaitingPage">
                                                    There are a Radiology Order
                                                    
                                                </a>
                                            </div>
                                        </li>`);
    playAudio();
    var counter1 = parseInt($('#notificationCounter').text());

    counter1 = counter1 + 1;
    $('#notificationCounter').text(counter1);
});


connection.start();

function playAudio() {
    x.play();
}