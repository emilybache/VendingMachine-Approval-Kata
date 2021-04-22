#include <gtest/gtest.h>
#include <VendingMachine.h>
#include <VendingMachinePrinter.h>
#include <ApprovalTests/Approvals.h>

#include "VendingMachineTest.h"

using namespace std;


TEST_F(VendingMachineTest, InsertCoins)
{
    string toApprove = printer->print();

    toApprove += insertCoin("nickel");
    toApprove += printer->print();

    toApprove += insertCoin("dime");
    toApprove += printer->print();

    toApprove += insertCoin("quarter");
    toApprove += printer->print();

    toApprove += insertCoin("penny");
    toApprove += printer->print();

    ApprovalTests::Approvals::verify(toApprove);

}



