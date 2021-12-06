package at.resign;

import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;

import java.net.URL;
import java.util.ResourceBundle;

public class PrototypeController implements Initializable {
    public Label lblRoomNumber;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        lblRoomNumber.setText(App.getRoomNumber());
    }

    public void btn_dakrmodeToggle_click(MouseEvent mouseEvent) {
        try {
            App.toggleDarkMode();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
