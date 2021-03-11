from vending_machine import VendingMachine


class VendingMachinePrinter:
    def __init__(self, machine : VendingMachine):
        self.columns = 60
        self.machine = machine

    def print_everything(self, include_empty=True):
        text = "VendingMachine\n"
        text += self.format_line_with_whitespace("Display", self.machine.display)
        fields = [
            ("Balance", self.machine.balance),
            ("Coins", self.machine.coins),
            ("Returns", self.machine.returns),
            ("Selected product", self.machine.selected_product),
            ("Dispensed product", self.machine.dispensed_product),
            ("Stock", self.machine.stock),
            ("Banked Coins", self.machine.bank),
        ]
        for name, field in fields:
            if field or include_empty:
                text += self.format_line_with_whitespace(name, field)

        text += "\n"
        return text

    def print_significant_fields(self):
        return self.print_everything(include_empty=False)

    def format_line_with_whitespace(self, name, value):
        value_as_str = f"{value}"
        whitespace_size = self.columns - len(name) - len(value_as_str)
        whitespace = ""
        for i in range(whitespace_size):
            whitespace += " "
        line = f"{name}{whitespace}{value_as_str}\n"
        return line
