# Java Class 03 Overview

# Creating Buttons
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
# JTextArea
### Appending
```Java
JTextArea myTextArea = JTextArea();
myTextArea.append("NewString");
// Add a \n to add a new line
myTextArea.append("\nNewString");
```
