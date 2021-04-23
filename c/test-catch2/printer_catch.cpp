#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include <string>

extern "C"
{
#include "vending_machine_printer.h"
#include "vending_machine.h"
#include "coin.h"
}

using namespace std;

TEST_CASE ("VendingMachinePrinter") {
    struct vending_machine* machine = vending_machine_create();
    char buffer[MAX_PRINT_LENGTH];

    SECTION("default") {
        print_machine(machine, buffer);
        ApprovalTests::Approvals::verify(string(buffer));
    }

    SECTION("format line with whitespace") {
        char line[LINE_LENGTH];
        string key = "Key";
        string value = "A Value";

        print_line(line, key.c_str(), value.c_str());
        ApprovalTests::Approvals::verify(string(line));
    }

    SECTION("format array of coins") {
        int coins[] = {5, 10, 25, 1};
        print_coins(buffer, coins, 4);
        ApprovalTests::Approvals::verify(string(buffer));
    }

    SECTION("format array of coins on line") {
        int coins[] = {5, 10, 25, 1};
        char coins_as_string[buffer_size_for_coins(4)];
        print_coins(coins_as_string, coins, 4);
        print_line(buffer, "Coins", coins_as_string);
        ApprovalTests::Approvals::verify(string(buffer));
    }
}




