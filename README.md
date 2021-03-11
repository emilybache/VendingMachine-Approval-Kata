# Vending Machine Approval Kata

This is starting code for doing approval testing for the [Vending Machine Kata](https://sammancoaching.org/kata_descriptions/vending_machine.html).

1. The starting position has a functioning test for the first feature. Re-write it to instead use Approval testing.
1. Write new tests to check the other coin types work correctly.
1. Apply the 'return_coins.patch' feature. (see below for git instruction)
   This is to simulate some developers adding this feature and forgetting to add a test for it. 
   Write a new test for this feature using your printer.
1. Apply the 'select_product.patch' feature. Write a test for this one too.
1. Apply the 'exact change' feature. Write a test for this one too.

To apply a patch use:

	git apply filename.patch
    
To un-apply a patch use:

    git apply -R filename.patch
       