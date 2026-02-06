const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.on("ReceiveMessage", function (messageId, user, message) {
    $("#chat").append(
        `<li data-message-id="${messageId}">
            <strong>${user}</strong>: ${message}
            <ul class="comments"></ul>
        </li>`
    );
});

connection.start()
    .then(() => console.log("Connected"))
    .catch(err => console.error(err));

$("#sendButton").click(function () {
    const user = $("#userInput").val();
    const message = $("#messageInput").val();

    if (!message) return;

    connection.invoke("SendMessage", user, message)
        .catch(err => console.error(err));
});