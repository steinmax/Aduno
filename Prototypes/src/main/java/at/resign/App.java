package at.resign;

import javafx.application.Application;
import javafx.application.Platform;
import javafx.beans.value.ObservableValue;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.stage.Stage;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * JavaFX App
 */
public class App extends Application {
    protected static Scene scene;
    private static boolean isDarkModeEnabled = false;

    private static String initFxmlFile = "display-light";
    private static String roomNumber = "---";

    public static String getRoomNumber() {
        return roomNumber;
    }
    public static void setRoomNumber(String roomNumber) {
        App.roomNumber = roomNumber;
    }

    public static void toggleDarkMode() throws IOException {
        if(isDarkModeEnabled) {
            setRoot("display-light");
            isDarkModeEnabled = false;
        }
        else {
            setRoot("display-dark");
            isDarkModeEnabled = true;
        }
    }

    public static void showDisplay() throws IOException {
        if(isDarkModeEnabled) {
            setRoot("display-dark");
        }
        else {
            setRoot("display-light");
        }
    }

    @Override
    public void start(Stage stage) throws IOException {
        scene = new Scene(loadFXML(initFxmlFile), 1024, 600);
        stage.setScene(scene);
        stage.show();
    }

    protected static void setRoot(String fxml) throws IOException {
        scene.setRoot(loadFXML(fxml));
    }

    protected static Parent loadFXML(String fxml) throws IOException {
        FXMLLoader fxmlLoader = new FXMLLoader(App.class.getResource(fxml + ".fxml"));
        return fxmlLoader.load();
    }

    public static void main(String[] args) {
        if(args.length>0)
            if(args[0].equalsIgnoreCase("-setup"))
                initFxmlFile = "setup-1";
            else if(args[0].equalsIgnoreCase("-xmas"))
                initFxmlFile = "xmasbackground";

        launch();
    }

}