CONDITION:
There are 3 different folders (DR, ES, EU). Each folder contains several subfolders. Name of the valid folder must meet the following requirements: 
Begins with two letters in the upper case, followed by one space or one dash, followed by 4 and up to 8 any symbols, followed by one space or one dash, followed by 4 digits. Each main folder (DR, ES, EU) must contain only subfolders that start with a prefix equal to main folder type (DR, ES, EU).
Folders contain xml and json files that contain Title fields.

TO-DO:
Create console application that can perform the following:
Find all values of Title field from all xml and json files in folders with valid name and save all Title field values in a separate .txt file for each type of folder. The name of saved file should match the folder type (DR, ES, EU). You need to crawl entire folder tree for each folder type.