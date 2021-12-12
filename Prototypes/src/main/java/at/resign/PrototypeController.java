package at.resign;

import javafx.application.Platform;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.scene.input.MouseEvent;

import java.net.URL;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.ResourceBundle;

public class PrototypeController implements Initializable {
    public Label lblRoomNumber;
    public Label lblDate;
    public Label time;

    @Override
    public void initialize(URL url, ResourceBundle resourceBundle) {
        lblRoomNumber.setText(App.getRoomNumber());
        lblDate.setText(LocalDate.now().format(DateTimeFormatter.ofPattern("dd.MM.yyyy")));
        ClockThread(time);
    }

    public void btn_dakrmodeToggle_click(MouseEvent mouseEvent) {
        try {
            App.toggleDarkMode();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void ClockThread(Label time) {
        final Thread thread = new Thread(() -> {
            SimpleDateFormat sdf = new SimpleDateFormat("HH:mm:ss");
            while(true){
                try{
                    Thread.sleep(1000);
                } catch (InterruptedException e){
                    e.printStackTrace();
                }
                String currentTime = sdf.format(new Date().getTime());
                Platform.runLater(()->time.setText(currentTime));
            }
        });
        thread.setDaemon(true);
        thread.start();
    }
}
