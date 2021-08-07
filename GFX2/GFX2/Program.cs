using System;
using System.Windows.Forms;
using Domain;
using GFX2.Domain;
using UI;


static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // maak een venster aan
        Form form = new Form();

        // stel de initiele grootte van dit venster in
        form.ClientSize = new System.Drawing.Size(400, 500);

        // stel de titel van het venster in
        form.Text = "Diagram";

        // maak een diagram en voeg twee rechthoeken toe
        Diagram diagram = new Diagram();
        Rectangle r1 = new Rectangle(100, 100, 100, 200, System.Drawing.Color.Red, true);
        diagram.AddRectangle(r1);
        Circle c1 = new Circle(150, 150, 60, System.Drawing.Color.Green, true);
        diagram.AddCircle(c1);
        Circle c2 = new Circle(325, 285, 30, System.Drawing.Color.Yellow, true);
        diagram.AddCircle(c2);
        Rectangle r2 = new Rectangle(300, 300, 50, 50, System.Drawing.Color.Blue, true); 
        diagram.AddRectangle(r2);

        // maak een control (= ui onderdeel) en voeg toe aan dit venster
        Control control = new DiagramControl(diagram);
        form.Controls.Add(control);

        // zorg ervoor dat drawing control ganse venster inneemt
        control.Dock = DockStyle.Fill;

        // Start de grafische user interface en toon de form
        Application.Run(form);
    }
}