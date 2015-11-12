
public class MainForm {

	public static void main(String[] args) {		
		// Create a leap listener and assign it to a controller to receive events
	    LeapListener listener = new LeapListener();
	    Controller controller = new Controller(listener);
	    
	    

	    //The controller must be disposed of before the listener
	    controller = null;
	}

}
