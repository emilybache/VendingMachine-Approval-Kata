# Vending Machine Approval Kata - TextTest version

This branch shows a sample solution with texttest.

Exercises
---------

1. The requirements changed! After you buy a product it should display the text "ENJOY!" instead of "THANK YOU". Make this change in the code and then update the tests.
2. The development team decided to rename the method 'tick' to 'refresh_display'. Update the tests to use the new method.
3. The development team decided to rename the method 'select_product' on VendingMachine to 'choose_product'. Update the tests to use the new 'choose_product' method. Change them back to use 'select_product' when you can explain why the code is divided into 'use_case.py' and 'step_definitions.py'.
4. It turns out, when they re-named the method to 'choose_product', the development team also changed how it works! It now displays a message "CONFIRM SELECTION" the first time you choose a product and only dispenses the item if you choose the product a second time. Write a test specifically for this updated feature. 
5. Update the existing tests to use 'choose_product' instead of 'select_product' in all places.
