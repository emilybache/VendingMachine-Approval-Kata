using System.ComponentModel.DataAnnotations;

namespace VendingMachine_Approval_Kata;

public class VendingMachinePrinter
{

        private readonly int _columns;
        private readonly VendingMachine _machine;

        public VendingMachinePrinter(VendingMachine machine) {
            _columns = 60;
            _machine = machine;
        }
        
        private String Line(String name, String value){
            int whitespaceSize = _columns - name.Length - value.Length;
            String whiteSpace = "";
            for (int i = 0; i < whitespaceSize; i++) {
                whiteSpace += " ";
            }

            return name + whiteSpace + value;
        }
        private String Line(String name, List<int> value){
            return Line(name, string.Join(", ", value));
        }
        private String Line(String name, Dictionary<string, int> value){
            return Line(name, string.Join(", ", value));
        }

        public string PrintEverything()
        {
            return $@"VendingMachine
{Line("Display", _machine.Display)}
{Line("Balance", ""+_machine.Balance)}
{Line("Returns", _machine.Returns)}
{Line("Selected product", ""+_machine.SelectedProduct)}
{Line("Dispensed product", ""+_machine.DispensedProduct)}
{Line("Stock", _machine.Stock)}
{Line("Banked Coins", _machine.Bank)}
";
        }
}