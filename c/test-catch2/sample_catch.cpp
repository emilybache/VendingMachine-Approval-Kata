#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"
#include <string>
#include <sstream>

extern "C"
{
#include "vending_machine.h"
#include "coin.h"
#include "vending_machine_printer.h"
}

using namespace std;

string print_machine(struct vending_machine* machine) {
    stringstream printout;

    printout << "Display:\t\t\t" << machine->display << '\n';
    printout << "Balance:\t\t\t" << machine->balance << '\n';
    printout << "Coin Count:\t\t\t" << machine->coin_count << '\n';
    for (int i = 0; i < machine->coin_count; i++) {
        printout << machine->coins[i] << ',';
    }
    printout << '\n';
    return printout.str();
}

TEST_CASE ("VendingMachine") {
    auto machine = vending_machine_create();

    SECTION("insert nickel (original test)") {
        CHECK("INSERT COIN" == string(machine->display));

        insert_coin(machine, coin_with_name("nickel"));

        CHECK("$0.05" == string(machine->display));
        CHECK(5 == machine->balance);
        CHECK(1 == machine->coin_count);
        CHECK(5 == machine->coins[0]);
    }


    SECTION("insert nickel (with stringstream)") {
        stringstream printout;
        printout << "Initial state:\n" << print_machine(machine);

        auto coin_name = "nickel";
        printout << "insert coin " << coin_name << "\n\n";
        insert_coin(machine, coin_with_name(coin_name));

        printout << "Final state:\n"<< print_machine(machine);
        ApprovalTests::Approvals::verify(printout.str());
    }

    SECTION("insert nickel (with printer in c)") {
        CHECK("INSERT COIN" == string(machine->display));

        insert_coin(machine, coin_with_name("nickel"));

        char buffer[MAX_PRINT_LENGTH];
        print_machine(machine, buffer);

        ApprovalTests::Approvals::verify(string(buffer));
    }
}


