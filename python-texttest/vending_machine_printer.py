from vending_machine import VendingMachine


class VendingMachinePrinter:
    def __init__(self, machine : VendingMachine):
        self.columns = 60
        self.machine = machine

    def print(self):
        text = "VendingMachine: TODO - implement this printer\n"
        # TODO: finish this
        return text

    def format_line_with_whitespace(self, name: str, value):
        """
        Convenience function that lays out a name and a value at either ends of a fixed-width line.
        eg if you call it with name="Foo" value="Bar" it will return

        Foo                                       Bar

        """
        value_as_str = f"{value}"
        whitespace_size = self.columns - len(name) - len(value_as_str)
        whitespace = ""
        for i in range(whitespace_size):
            whitespace += " "
        line = f"{name}{whitespace}{value_as_str}\n"
        return line
