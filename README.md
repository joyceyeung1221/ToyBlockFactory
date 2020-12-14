# Toy Block Factory
### About this Kata
The goal of this kata is to create an order management system for a make-to-order toy block factory to handle their customers orders and to produce different types of reports for each individual order.

[Link to the kata repository](https://github.com/joyceyeung1221/General_Developer/tree/main/katas/kata-toy-block-factory)

### What I have done
I impletmented this kata as a **console application** using **C#** language. 

The applications allows user to manually record each individual order through the console, and three different reports will prompt to the console upon the completion of the data entry.

As the domain is relatively simple, thus, I also completed one of the customizations suggested in the respository - **Loading from CSV File**.

The user can input their order/s through recording order/s in a CSV file in a specific format. If the file and data are processed successfully, an invoice report will be output as a CSV file by the application.

### Why I did it
This kata was initially chosen for practicing the use of the following concepts in design and development, but I later decided to also use it in my first quorum review presentation.
- Test-Driven Development
- Single responsibility
- Command Query Separation
- Composition
- Interface & abstract class
- First class collection
- Factory pattern
- Error handling
- Read and print CSV file
- Third party library

### How to run
For console input and console output - 
The application can be executed simply by pressing the **Run** button in most common IDE. Or through a terminal using the following command
```
dotnet run
```

For CSV input and CSV output - 
A complete file directory needs to be provided as an argument following the command.
```
dotnet run "C:/filepathInsertHere"
```
Currently the output file name and input test file are hardcoded in the CSVReportPrinter Class and the CSVReaderInputTest class. In order to have the CSV output option and the test executed without errors, you will need to update the file path set to be your local directory accordingly.

