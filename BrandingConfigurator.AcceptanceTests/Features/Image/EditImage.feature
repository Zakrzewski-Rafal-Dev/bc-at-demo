Feature: Edit image

Scenario: Edit Cmyk color in image
    Given I have uploaded pdf image file
    When I change Cmyk color
    Then Cmyk color is changed

Scenario: Edit Pantone color in image
    Given I have uploaded pdf image file
    When I change Pantone color
    Then Pantone color is changed
    
Scenario: Edit Cmyk color in image by extended model 
    Given I have uploaded pdf image file
    When I change Cmyk color by extended model
    Then Cmyk color is changed by extended model

Scenario: Edit Pantone color in image by extended model
    Given I have uploaded pdf image file
    When I change Pantone color by extended model
    Then Pantone color is changed by extended model 

Scenario: Edit different Cmyk colors in image
    Given I have uploaded pdf image file
    When I change Cmyk colors
    Then Cmyk colors are changed

Scenario: Edit different Pantone colors in image
    Given I have uploaded pdf image file
    When I change Pantone colors
    Then Pantone colors are changed
  
Scenario: Edit Cmyk colors in image by extended model
    Given I have uploaded pdf image file
    When I change Cmyk colors by extended model
    Then Cmyk colors are changed by extended model

Scenario: Edit Pantone colors in image by extended model
    Given I have uploaded pdf image file
    When I change Pantone colors by extended model
    Then Pantone colors are changed by extended model
  
Scenario: Edit different Cmyk colors in image by extended and legacy models 
    Given I have uploaded pdf image file
    When I change Cmyk colors by extended and legacy models
    Then Cmyk colors are changed by extended and legacy models

Scenario: Edit different Pantone colors in image by extended and legacy models
    Given I have uploaded pdf image file
    When I change Pantone colors by extended and legacy models
    Then Pantone colors are changed by extended and legacy models  
  
Scenario: Edit the same Cmyk color many times in image
    Given I have uploaded pdf image file
    When I change the same Cmyk color many times
    Then Cmyk color is changed

Scenario: Edit the same Cmyk color many times in image by extended model
    Given I have uploaded pdf image file
    When I change the same Cmyk color many times by extended model
    Then Cmyk color is changed by extended model  
     
Scenario: Edit the same Pantone color many times in image
    Given I have uploaded pdf image file
    When I change the same Pantone color many times 
    Then Pantone color is changed
   
Scenario: Edit the same Pantone color many times in image by extended model
    Given I have uploaded pdf image file
    When I change the same Pantone color many times by extended model
    Then Pantone color is changed by extended model  
    
Scenario: Do not edit absent Cmyk color in image
    Given I have uploaded pdf image file
    When I change absent Cmyk color
    Then Cmyk color is not found in image
    Then Original Cmyk colors has not been changed

Scenario: Do not edit absent Pantone color in image
    Given I have uploaded pdf image file
    When I change absent Pantone color
    Then Pantone color is not found in image
    Then Original Pantone colors has not been changed

Scenario: Do not edit absent Cmyk color in image by extended model
    Given I have uploaded pdf image file
    When I change absent Cmyk color by extended model
    Then Cmyk color is not found in image
    Then Original Cmyk colors has not been changed

Scenario: Do not edit absent Pantone color in image by extended model
    Given I have uploaded pdf image file
    When I change absent Pantone color by extended model
    Then Pantone color is not found in image
    Then Original Pantone colors has not been changed
    
Scenario: Do not edit Cmyk color to invalid Cmyk color in image
    Given I have uploaded pdf image file
    When I change to invalid Cmyk color
    Then Cmyk color is invalid
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Pantone color to invalid Pantone color in image
    Given I have uploaded pdf image file
    When I change to invalid Pantone color
    Then Pantone color is invalid
    Then Original Pantone colors has not been changed
 
Scenario: Do not edit Cmyk color to invalid Cmyk color in image by extended model
    Given I have uploaded pdf image file
    When I change to invalid Cmyk color by extended model
    Then Cmyk color is invalid
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Pantone color to invalid Pantone color in image by extended model
    Given I have uploaded pdf image file
    When I change to invalid Pantone color by extended model
    Then Pantone color is invalid
    Then Original Pantone colors has not been changed  

Scenario: Do not edit Cmyk color to the same Cmyk color in image
    Given I have uploaded pdf image file
    When I change to the same Cmyk color
    Then Cmyk colors are the same
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Pantone color to the same Pantone color in image
    Given I have uploaded pdf image file
    When I change to the same Pantone color
    Then Pantone colors are the same
    Then Original Pantone colors has not been changed

Scenario: Do not edit Cmyk color to the same Cmyk color in image by extended model
    Given I have uploaded pdf image file
    When I change to the same Cmyk color by extended model
    Then Cmyk colors are the same
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Pantone color to the same Pantone color in image by extended model
    Given I have uploaded pdf image file
    When I change to the same Pantone color by extended model
    Then Pantone colors are the same
    Then Original Pantone colors has not been changed  

Scenario: Do not edit undefined Cmyk color in image
    Given I have uploaded pdf image file
    When I change undefined Cmyk color
    Then Cmyk color is undefined
    Then Original Cmyk colors has not been changed

Scenario: Do not edit undefined Cmyk color in image by extended model
    Given I have uploaded pdf image file
    When I change undefined Cmyk color by extended model
    Then Cmyk color is undefined in extended model
    Then Original Cmyk colors has not been changed

Scenario: Do not edit undefined Pantone color in image
    Given I have uploaded pdf image file
    When I change undefined Pantone color
    Then Pantone color is undefined
    Then Original Pantone colors has not been changed

Scenario: Do not edit undefined Pantone color in image by extended model
    Given I have uploaded pdf image file
    When I change undefined Pantone color by extended model
    Then Pantone color is undefined in extended model
    Then Original Pantone colors has not been changed  
    
Scenario: Do not edit Cmyk color to undefined Cmyk color in image
    Given I have uploaded pdf image file
    When I change to undefined Cmyk color
    Then Cmyk color is undefined
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Pantone color to undefined Pantone color in image
    Given I have uploaded pdf image file
    When I change to undefined Pantone color
    Then Pantone color is undefined
    Then Original Pantone colors has not been changed
    
Scenario: Do not edit no colors in image
    Given I have uploaded pdf image file
    When I change no colors
    Then No colors to change
    Then Original Cmyk colors has not been changed          
    Then Original Pantone colors has not been changed          

Scenario: Do not edit Cmyk and Pantone colors at once in image
    Given I have uploaded pdf image file
    When I change Cmyk and Pantone colors
    Then There are two types of colors
    Then Original Cmyk colors has not been changed    
    Then Original Pantone colors has not been changed 

Scenario: Do not edit Cmyk and Pantone colors at once in image by extended model
    Given I have uploaded pdf image file
    When I change Cmyk and Pantone colors by extended model
    Then There are two types of colors
    Then Original Cmyk colors has not been changed    
    Then Original Pantone colors has not been changed 
     
Scenario: Hide shown Cmyk color in image
    Given I have uploaded pdf image file
    When I hide Cmyk color
    Then Cmyk color is hidden

Scenario: Hide shown Pantone color in image
    Given I have uploaded pdf image file
    When I hide Pantone color
    Then Pantone color is hidden

Scenario: Hide hidden Cmyk color in image
    Given I have uploaded pdf image file
    When I hide Cmyk color
    When I hide Cmyk color
    Then Cmyk color is hidden
    
Scenario: Hide hidden Pantone color in image
    Given I have uploaded pdf image file
    When I hide Pantone color
    When I hide Pantone color
    Then Pantone color is hidden
    
Scenario: Show hidden Cmyk color in image
    Given I have uploaded pdf image file
    When I hide Cmyk color
    When I show Cmyk color
    Then Cmyk color is shown 

Scenario: Show hidden Pantone color in image
    Given I have uploaded pdf image file
    When I hide Pantone color
    When I show Pantone color
    Then Pantone color is shown
             
Scenario: Show shown Cmyk color in image
    Given I have uploaded pdf image file
    When I show Cmyk color
    Then Cmyk color is shown

Scenario: Show shown Pantone color in image
    Given I have uploaded pdf image file
    When I show Pantone color
    Then Pantone color is shown
        
Scenario: Do not shown invalid Cmyk color in image
    Given I have uploaded pdf image file
    When I hide Cmyk color
    When I show invalid Cmyk color
    Then Pantone color is not found in image
    Then Cmyk color has not been shown

Scenario: Do not shown invalid Pantone color in image
    Given I have uploaded pdf image file
    When I hide Pantone color
    When I show invalid Pantone color
    Then Pantone color is not found in image
    Then Pantone color has not been shown
           
Scenario: Do not hide invalid Cmyk color in image
    Given I have uploaded pdf image file
    When I hide invalid Cmyk color
    Then Pantone color is not found in image
    Then Cmyk color has not been hidden
        
Scenario: Do not hide invalid Pantone color in image
    Given I have uploaded pdf image file
    When I hide invalid Pantone color
    Then Pantone color is not found in image
    Then Pantone color has not been hidden 

Scenario: Do not hide Cmyk and Pantone color in image
    Given I have uploaded pdf image file
    When I hide Cmyk and Pantone colors
    Then There are two types of colors
    Then Cmyk and Pantone colors have not been changed 

Scenario: Edit Cmyk color in image by Cmyk id 
    Given I have uploaded pdf image file
    When I change Cmyk color by Cmyk id
    Then Cmyk color is changed by Cmyk id

Scenario: Edit Cmyk colors in image by Cmyk id
    Given I have uploaded pdf image file
    When I change Cmyk colors by Cmyk id
    Then Cmyk colors are changed by Cmyk id

Scenario: Edit different Cmyk colors in image by Cmyk id and legacy models 
    Given I have uploaded pdf image file
    When I change Cmyk colors by Cmyk id and legacy models
    Then Cmyk colors are changed by extended and legacy models

Scenario: Edit the same Cmyk color many times in image by Cmyk id
    Given I have uploaded pdf image file
    When I change the same Cmyk color many times by Cmyk id
    Then Cmyk color is changed by Cmyk id

Scenario: Do not edit absent Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I change absent Cmyk color by Cmyk id
    Then Cmyk color is not found in image
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Cmyk color to invalid Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I change to invalid Cmyk color by Cmyk id
    Then Cmyk color is invalid
    Then Original Cmyk colors has not been changed

Scenario: Do not edit Cmyk color to the same Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I change to the same Cmyk color by Cmyk id
    Then Cmyk colors are the same
    Then Original Cmyk colors has not been changed

Scenario: Do not edit undefined Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I change undefined Cmyk color by Cmyk id
    Then Cmyk color is undefined in extended model
    Then Original Cmyk colors has not been changed  

Scenario: Do not edit Cmyk and Pantone colors at once in image by Cmyk id
    Given I have uploaded pdf image file
    When I change Cmyk and Pantone colors by Cmyk id
    Then There are two types of colors
    Then Original Cmyk colors has not been changed    
    Then Original Pantone colors has not been changed

Scenario: Hide shown Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide Cmyk color by Cmyk id
    Then Cmyk color is hidden

Scenario: Hide hidden Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide Cmyk color by Cmyk id
    When I hide Cmyk color by Cmyk id
    Then Cmyk color is hidden

Scenario: Show hidden Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide Cmyk color by Cmyk id
    When I show Cmyk color by Cmyk id
    Then Cmyk color is shown

Scenario: Show shown Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I show Cmyk color by Cmyk id
    Then Cmyk color is shown

Scenario: Do not shown invalid Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide Cmyk color by Cmyk id
    When I show invalid Cmyk color by Cmyk id
    Then Pantone color is not found in image
    Then Cmyk color has not been shown  

Scenario: Do not hide invalid Cmyk color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide invalid Cmyk color by Cmyk id
    Then Pantone color is not found in image
    Then Cmyk color has not been hidden

Scenario: Do not hide Cmyk and Pantone color in image by Cmyk id
    Given I have uploaded pdf image file
    When I hide Cmyk and Pantone colors by Cmyk id
    Then There are two types of colors
    Then Cmyk and Pantone colors have not been changed 