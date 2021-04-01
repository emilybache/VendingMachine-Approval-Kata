#include "ApprovalTests.hpp"
#include "catch2/catch.hpp"

#include "VendingMachinePrinter.h"

using namespace std;

TEST_CASE ("VendingMachinePrinter") {
    auto* machine = new VendingMachine();
    auto printer = VendingMachinePrinter(machine);

    SECTION("format line") {
        CHECK(printer.formatLine("foo", "bar") == "foo                                                      bar\n");
    }

    SECTION("format list of strings") {
        auto* coins = new std::vector<int>(0, 0);
        coins->push_back(5);
        coins->push_back(10);
        CHECK(printer.printVector(coins) == "{5, 10}");
    }

    delete machine;
}




