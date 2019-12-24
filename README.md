# .net core 3 signalR Chat Application
.Net Core 3 signalR Chat Application.

You can join existing room or create a new room.

Simple Real Time Chat Example with critical features

![Room Page](https://image.prntscr.com/image/WFkirKIXTkqSRzvnTq3QUw.png)


.net core 3.x installation
---------------------------------
Download the  [.net core 3 sdk]

INSTALLATION
---------------------------------
```
git clone git@github.com:Lethea/.net-core3-signalr-chat.git
```

 There is two project 
1. .net Core 3 Solution : 
This includes SignalRTUts Project
   * ChatHub for websocket 
   * Models ( User, ResponseMessage ) 
   * Redis Configuration
   
2. Front End  : Basic Html & Jquery Project
   * This is for chatroom front end 
   * Allows user to login to the given room
   * Allows user to public chat
   * Listen login / disconnect event

```

Run The Solution
Put the html & js to the any web server such as apache, nginx or iis

```

CONFIGURATION
----------------------------------


```
const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:44342/chatHub")
            .configureLogging(signalR.LogLevel.Information)
            .build();
```

You can use your own Url behind Nginx Ssl.


CONNECT TO CHAT ROOM
-----------------------------

```
cd nodejsserver

node videochat.js
```

Open index.html with browser ( chrome preferred )

````
https://your_web_server_ip/signalrweb/index.html
````

Login Page

![Login Page](https://image.prntscr.com/image/WFkirKIXTkqSRzvnTq3QUw.png)

* Enter your nickname  (English Characters & Numbers without space required)
* Enter your Room Name (English Characters & Numbers without space required)

![Room Page](https://image.prntscr.com/image/E-Vp7aeLQkOtvqv-RdVT4w.png)

Note
-------------
For proxy pass you can use nginx as well

Features
-------------
- [x] Login 
- [x] Dynamic Chat Room
- [x] Text Chat
- [x] User Left Info
- [x] New User Login Info
- [x] User List
- [x] Redis Implementation
- [ ] Database Integration
- [ ] Personal Message
- [ ] Typo Control
- [ ] Test

Contact
------------
````
Mail : emre.karatasoglu@hotmail.com
Phone / Whatsapp / Telegram : +90 532 346 67 79
Donate :   1HxYXXDNQen9kDHjdjPrHkj1xS64fkENes ( BTC )
           Ld8BNcvP69146jgT5hVbTzSsnL7q6WoUSg ( LTC ) 
           0x77935c829b0f12b05151ec7bce31d58a97f735e8 ( ETH ) 
````






[.net core 3 sdk]:https://dotnet.microsoft.com/download
