
#include <sstream>
#include "VendingMachinePrinter.h"

VendingMachinePrinter::VendingMachinePrinter(VendingMachine* machine):
machine(machine), columns(60) {}

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

std::string VendingMachinePrinter::print() {
    std::string printout = "VendingMachine";
    // TODO: finish this

    return printout;
}

VendingMachinePrinter::~VendingMachinePrinter() {
    machine = nullptr;
}
