import os

import step_definitions
from step_definitions import Story
from vending_machine import VendingMachine
from vending_machine_printer import VendingMachinePrinter

if __name__ == "__main__":
    machine = VendingMachine(stock={"Cola": 1, "Chips": 1, "Candy": 1})
    printer = VendingMachinePrinter(machine)
    story = Story(printer)

    cwd = os.getcwd()
    try:
        use_case = os.path.join(os.getcwd(), "use_case.py")
        if os.path.isfile(use_case):
            with open(use_case, "r") as f:
                story.init(f"Feature: {str(os.path.basename(os.path.dirname(use_case))).replace('_', ' ')}")

                # put necessary objects into the current scope for the use case
                step_definitions.machine = machine
                step_definitions.printer = printer
                step_definitions.story = story

                # execute the use case
                exec(compile(f.read(), "use_case.py", 'exec'))
    finally:
        print(str(story))


