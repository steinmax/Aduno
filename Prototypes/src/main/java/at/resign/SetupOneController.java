package at.resign;

import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.util.Callback;

import java.net.URL;
import java.util.ResourceBundle;

public class SetupOneController implements Initializable {
    public ComboBox cbRooms;

    String selectedRoom = "-";

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        //Test Data
        cbRooms.getItems().add("132");
        cbRooms.getItems().add("132-1");
        cbRooms.getItems().add("133");
        cbRooms.getItems().add("134");
        cbRooms.getItems().add("135");
        cbRooms.getItems().add("210");
        cbRooms.getItems().add("E32");
        cbRooms.getItems().add("E32-A");
        cbRooms.getItems().add("E32-B");
        cbRooms.getItems().add("E34");
        cbRooms.getItems().add("E35");
        cbRooms.getItems().add("E10");
    }

    public void btnConfirmClick(MouseEvent mouseEvent) {
        //
    }
}
