# This application is used to create your own tournaments
## To create your personal tourney you need:
- Create your Teams(minimum 2 teams required)
  - To create your team you need to create members(Name, SecondName, Email, PhoneNumber)
* Create your Prizes for winners(as you wish)
* Enter Fee
* Click "Create Tournament" button


After you created tournament you will thrown to the Tournament Viever where you can score values for teams, and after you hit Score button values that you enter will be collected to database or to text file <h3>before starting application you should choose what type of data you want to return in Program.cs <h4>"Sql" for pulling to database</h4> to make this you need to enter values of your database in App.config (Server name, name of your database), <h4>"TextFile" to pull into csv format files</h4> you need to write filepath to pull csv information in App.config by value 'filepath'</h3>

### And thats it, now you can easily make your own tournies!


For those who want to send emails to team members created before you need to make your own SMTP server and user who will send emails automatically to them(better instruction written in EmailLogic.cs)
