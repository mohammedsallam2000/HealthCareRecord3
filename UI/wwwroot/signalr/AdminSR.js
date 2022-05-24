var x = document.getElementById("myAudio");
var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewSergery", function () {
   

   
    
    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/SurgeryDoctor/WaitingPage">
                                                    There are a surgery order
                                                    
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

