var x = document.getElementById("myAudio");

var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewSergery", function () {
    

    var counter1 = parseInt($('#notificationCounter').text());
    alert(counter1);
    counter1 = counter1 + 1;
    $('#notificationCounter').text(counter1);
    
    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/SurgeryDoctor/WaitingPage">
                                                    <strong>ther are an suregery</strong>
                                                    <i class="fas fa-angle-right"></i>
                                                </a>
                                            </div>
                                        </li>`);
    x.play();
});

connection.start();