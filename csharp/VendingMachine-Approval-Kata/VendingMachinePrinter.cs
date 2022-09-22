namespace VendingMachine_Approval_Kata;

public class VendingMachinePrinter
{

        private readonly int _columns;
        private readonly VendingMachine _machine;

        public VendingMachinePrinter(VendingMachine machine) {
            _columns = 60;
            _machine = machine;
        }

        private String print(){
            // TODO: finish this
            return "VendingMachine\n";
        }

        /** Convenience function that lays out a name and a value at either ends of a fixed-width line.
         eg if you call it with name="Foo" value="Bar" it will return
         Foo                                       Bar
         */
        private String formatLineWithWhitespace(String name, String value){
            int whitespaceSize = _columns - name.Length - value.Length;
            String whiteSpace = "";
            for (int i = 0; i < whitespaceSize; i++) {
                whiteSpace += " ";
            }

            return name + whiteSpace + value;
        }
}