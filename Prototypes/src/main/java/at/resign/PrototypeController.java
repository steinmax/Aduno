package at.resign;

import javafx.scene.input.MouseEvent;

public class PrototypeController {
    public void btn_dakrmodeToggle_click(MouseEvent mouseEvent) {
        try {
            App.toggleDarkMode();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
