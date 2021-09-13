A guick guide to the application. 

Application has been broken down into a pattern with Models Logic and Data.
Application works by reading a JSON file called JsonData.json which is located in the Data folder. That collections of Jsons is then modelled into a list of Trades. 
Trade is a class used to model the shape of data (located in the Models folder). 
Once the JSON is deserialized, DataSorter and ProfitCounter classes are used to query the list of Trade objects and calculate the profit and loss. Data is first sorted into 2 lists, one for buys and one for sells.
The sum of each is calculated and total buys is subtracted from total sells.

Dependency injection is also used here. In the Program.cs file a host builder is used to serve up JsonTradeDatabase class when an instance of ITradeDatabase is requested.
There are 2 classes that implement the ITradeDatabase interface: MockTradeDatabase and JsonTradeDatabase. 
Currently the latter is used however I kept the former for testing purposes and also to show my progression. 