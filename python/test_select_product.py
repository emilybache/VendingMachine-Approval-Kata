import pytest
from approvaltests import verify

from vending_machine import VendingMachine
from vending_machine_printer import VendingMachinePrinter

# needed by pytest fixtures
from test_vending_machine import machine, printer, coins

def test_select_product(machine: VendingMachine, printer: VendingMachinePrinter):
    # TODO: use the printer and approvaltests.verify instead of assertions

    machine.select_product("Cola")

    assert machine.display == "PRICE $1.00"

    machine.tick()

    assert machine.display == "INSERT COIN"


def test_pay_then_select_product(machine: VendingMachine, printer: VendingMachinePrinter, coins: dict):
    # TODO: use the printer and approvaltests.verify instead of assertions

    machine.insert_coin(coins["quarter"])
    machine.insert_coin(coins["quarter"])
    machine.insert_coin(coins["quarter"])
    machine.insert_coin(coins["quarter"])
    machine.select_product("Cola")

    assert machine.display == "THANK YOU"
    assert machine.dispensed_product == "Cola"

    machine.tick()

    assert machine.display == "INSERT COIN"

