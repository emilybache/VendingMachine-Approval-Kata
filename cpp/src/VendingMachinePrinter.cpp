
#include <sstream>
#include "VendingMachinePrinter.h"

VendingMachinePrinter::VendingMachinePrinter(VendingMachine* machine):
machine(machine), columns(60) {}

// convenience function to lay out a key value pair at either end of a line like this:
//
// foo                       bar
//
std::string VendingMachinePrinter::formatLine(std::string key, std::string value) {
    int whitespaceSize = columns - key.size() - value.size();
    std::string whitespace = std::string(whitespaceSize, ' ');
    std::stringstream stream;
    stream << key << whitespace << value;
    return stream.str();
}

std::string VendingMachinePrinter::print() {
    // TODO: finish this
    return "VendingMachine";
}

VendingMachinePrinter::~VendingMachinePrinter() {
    machine = nullptr;
}
