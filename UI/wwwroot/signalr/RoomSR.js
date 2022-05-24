var connection = new signalR.HubConnectionBuilder().withUrl("/Realtime").build();
connection.on("GetNewRoom", function () {

    $('#alertInfo').prepend(`<li class="nav-item">
                                            <div class="text-center">
                                                <a href="/Room/WaitingPage">
                                                    There are a Room order
                                                    
                                                </a>
                                            </div>
                                        </li>`);
    playAudio();
    var counter1 = parseInt($('#notificationCounter').text());

    counter1 = counter1 + 1;
    $('#notificationCounter').text(counter1);
});

connection.start();