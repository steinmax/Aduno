module at.resign {
    requires javafx.controls;
    requires javafx.fxml;

    opens at.resign to javafx.fxml;
    exports at.resign;
}