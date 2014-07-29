Feature: ThumbnailGeneration
	In order to adapt to varying display size for images
	I want to be able to generate adequate thumbnail size

Scenario: Display ratio is smaller than image ratio but both heights are equals
	Given The image size is 100 x 50 pixels
	And The display size is 110 x 50 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 100 x 50 pixels
	And The thumnails offsets are 5 pixels horizontally and 0 pixels vertically

Scenario: Display ratio is smaller than image ratio and display height is smaller than image height
	Given The image size is 100 x 50 pixels
	And The display size is 110 x 40 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 80 x 40 pixels
	And The thumnails offsets are 15 pixels horizontally and 0 pixels vertically

Scenario: Display ratio is smaller than image ratio and display dimensions are smaller than image dimensions
	Given The image size is 100 x 50 pixels
	And The display size is 20 x 12 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 20 x 10 pixels
	And The thumnails offsets are 0 pixels horizontally and 1 pixels vertically
	
Scenario: Display ratio is equal to image ratio and display dimensions are equal to image dimensions
	Given The image size is 100 x 50 pixels
	And The display size is 100 x 50 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 100 x 50 pixels
	And The thumnails offsets are 0 pixels horizontally and 0 pixels vertically
		
Scenario: Display ratio is equal to image ratio and display dimensions are smaller than image dimensions
	Given The image size is 100 x 50 pixels
	And The display size is 12 x 6 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 12 x 6 pixels
	And The thumnails offsets are 0 pixels horizontally and 0 pixels vertically
			
Scenario: Display ratio is equal to image ratio and display dimensions are large than image dimensions
	Given The image size is 12 x 6 pixels
	And The display size is 100 x 50 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 100 x 50 pixels
	And The thumnails offsets are 0 pixels horizontally and 0 pixels vertically
	
Scenario: Display ratio is larger than image ratio but both heights are equals
	Given The image size is 100 x 50 pixels
	And The display size is 100 x 60 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 100 x 50 pixels
	And The thumnails offsets are 0 pixels horizontally and 5 pixels vertically
		
Scenario: Display ratio is larger than image ratio and display height is smaller than image height
	Given The image size is 100 x 50 pixels
	And The display size is 50 x 20 pixels
	When The thumbnail generator is initialized
	Then The thumbnail size is 40 x 20 pixels
	And The thumnails offsets are 5 pixels horizontally and 0 pixels vertically