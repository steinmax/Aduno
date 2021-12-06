package at.resign;

import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.input.MouseEvent;
import javafx.util.Callback;

import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;

public class SetupOneController implements Initializable {
    public ComboBox cbRooms;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        // ADDING TEST DATA:
        String[] roomNumbers = new String[] { "132", "132-1", "133", "134", "135", "210", "E32", "E32-A", "E32-B", "E34", "E35", "E10" };
        for (String roomNumber : roomNumbers) {
            cbRooms.getItems().add(roomNumber);
        }
    }

    public void btnConfirmClick(MouseEvent mouseEvent) {
        //Set room number
        App.setRoomNumber(cbRooms.getSelectionModel().getSelectedItem().toString());

        //Load Display UI
        try {
            App.showDisplay();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
