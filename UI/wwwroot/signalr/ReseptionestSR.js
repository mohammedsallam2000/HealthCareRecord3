var x = document.getElementById("myAudio");
var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewlab", function () {

    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/LabDoctor/WaitingPage">
                                                    ther are an Analysis
                                                    
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
                                                    ther are an Treatment
                                                    
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
                                                    ther are an Radiology
                                                    
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