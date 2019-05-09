1 - git clone https://github.com/Arkrait/TiburonTest.git
2 - cd TiburonTest
3 - dotnet ef migrations add InitialCreate 
4 - dotnet ef database update
5 - DB_PASS=<ваш_пароль_от_sqlserver> dotnet run & cd spa && npm start
(NOTE: попытки подключиться идут к локальному серверу)