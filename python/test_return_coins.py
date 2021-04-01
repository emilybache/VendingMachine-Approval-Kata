from approvaltests import verify

from vending_machine import VendingMachine
from vending_machine_printer import VendingMachinePrinter

# needed by pytest to find fixtures
from test_vending_machine import machine, printer, coins


def test_return_coins(machine: VendingMachine, printer: VendingMachinePrinter, coins: dict):
    # TODO: use the printer and approvaltests.verify instead of assertions

    machine.insert_coin(coins["nickel"])
    machine.return_coins()

    assert machine.balance == 0
    assert machine.returns == [5]
