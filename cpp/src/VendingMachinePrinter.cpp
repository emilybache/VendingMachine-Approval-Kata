
#include <sstream>
#include "VendingMachinePrinter.h"

VendingMachinePrinter::VendingMachinePrinter(VendingMachine* machine):
machine(machine), columns(50) {}



std::string VendingMachinePrinter::print() {
    std::string printout = "VendingMachine:\n";
    printout += formatLine("Display", machine->display);
    printout += formatLine("Balance", std::to_string(machine->balance));
    printout += formatLine("Coins", printVector(machine->coins));
    printout += formatLine("Returns", printVector(machine->returns));

    return printout;
}

VendingMachinePrinter::~VendingMachinePrinter() {
    machine = nullptr;
}

// convenience function to lay out a key value pair at either end of a line like this:
//
// foo                       bar
//
std::string VendingMachinePrinter::formatLine(const std::string& key, const std::string& value) const {
    auto whitespaceSize = columns - key.size() - value.size();
    std::string whitespace = std::string(whitespaceSize, ' ');
    std::stringstream stream;
    stream << key << whitespace << value << '\n';
    return stream.str();
}

// convenience function to print a vector of integers in a readable way
// {5, 10}
std::string VendingMachinePrinter::printVector(const std::vector<int>* items) const {
    std::stringstream stream;
    stream << "{";
    std::string separator;
    for (auto const& value : *items) {
        stream << separator << value;
        separator = ", ";
    }
    stream << "}";
    return stream.str();
}
