# Java Class 03 Overview

# JButton
### Creating buttons
When you click a button, it generates an action event, which then calles the code like a normal function.

```Java
// Button code example #1
private void yourButtonActionPerformed(java.awt.event.ActionEvent evt) {                                         
        // TODO add your handling code here:
}
// Button code example #2
yourButton.addActionListener((final ActionEvent e) -> {
	// TODO add your handling code here:
});
```
### Clicking a button when a user presses 'enter'
```Java
JButton myButton = new JButton("Enter");
JTextField myInput = new JTextField();
KeyListener keyListener = new KeyListener() {
	public void keyPressed(KeyEvent keyEvent) {
        	int keyCode = keyEvent.getKeyCode();
                String kt = Character.toString(keyEvent.getKeyChar());
                if (keyEvent.getKeyCode() == KeyEvent.VK_ENTER) {
                    myButton.doClick();
                }
	}

	public void keyReleased(KeyEvent keyEvent) {
	}

	public void keyTyped(KeyEvent keyEvent) {
	}
	};
myInput.addKeyListener(keyListener);
```
# Text
To set the text for ither a JTextArea of a JTextField, you do so like so:
``` Java
JTextArea myTextArea = JTextArea();
JTextField myTextField = new JTextField();
myTextArea.setText("New Text");
myTextField.setTexT("New Text");
```
### JTextArea
#### Appending
```Java
JTextArea myTextArea = JTextArea();
myTextArea.append("NewString");
// Add a \n to add a new line
myTextArea.append("\nNewString");
```
# JComboBox
Since you can select multiple values in a JComboBox, it will return an array. To get the first selected object you would accomplish it like this.
```Java
System.out.println(((String[])combo.getSelectedItem())[0]);
```
# JOptionPane
```Java
Object[] options1 = { "Yes custom text", "No custom text", "Quit custom text" };

JPanel panel = new JPanel();
panel.add(new JLabel("Some text"));
JTextField textField = new JTextField(10);
panel.add(textField);

int result = JOptionPane.showOptionDialog(null, panel, "Title of popup",
	JOptionPane.YES_NO_CANCEL_OPTION, JOptionPane.PLAIN_MESSAGE,
	null, options1, null);
if (result == JOptionPane.YES_OPTION){
    JOptionPane.showMessageDialog(null, textField.getText());
}
```
