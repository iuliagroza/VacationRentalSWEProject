import React, { useState } from "react";
import { AppBar, Box, Button, Divider, Drawer, IconButton, ListItemButton, ListItemText, Toolbar, Typography, colors } from "@mui/material";
import { Link, useLocation } from "react-router-dom";
import HomeIcon from '@mui/icons-material/Home';
import LocalLibraryIcon from "@mui/icons-material/LocalLibrary";
import AddIcon from '@mui/icons-material/Add';
import { useMediaQuery } from 'react-responsive'
import MenuIcon from "@mui/icons-material/Menu";
import CloseIcon from "@mui/icons-material/Close";

export const AdminMenu = () => {
    const location = useLocation();
    const path = location.pathname;
    const [open, setState] = useState(false);

    const isBigScreen = useMediaQuery({ query: '(min-width: 675px)' });

    const toggleDrawer = (open: any) => (event: any) => {
        if (
            event.type === "keydown" &&
            (event.key === "Tab" || event.key === "Shift")
        ) {
            return;
        }
        //changes the function state according to the value of open
        setState(open);
    };

    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static" sx={{ marginBottom: "20px", backgroundColor: colors.pink[500] }}>
                <Toolbar>
                    <Button
                        to="/admin"
                        component={Link}
                        color="inherit"
                        sx={{ mr: 2 }}
                        startIcon={<HomeIcon />}>
                    </Button>
                    <Typography variant="h6" component="div" sx={{ mr: 5 }}>
                        Vacation Rentals - Admin
                    </Typography>
                    {isBigScreen && <Button
                        variant={path.startsWith("/admin/public-dest/view") ? "outlined" : "text"}
                        to="/admin/public-dest/view"
                        component={Link}
                        color="inherit"
                        sx={{ mr: 4 }}
                        startIcon={<LocalLibraryIcon />}>
                        Public Destinations
                    </Button>}
                    {isBigScreen && <Button
                        variant={path.startsWith("/admin/public-dest/add") ? "outlined" : "text"}
                        to="/admin/public-dest/add"
                        component={Link}
                        color="inherit"
                        sx={{ mr: 4 }}
                        startIcon={<AddIcon />}>
                        Add Public Destination
                    </Button>}
                    {!isBigScreen && <IconButton
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                        onClick={toggleDrawer(true)}
                        sx={{
                            ml: "auto",
                            display: isBigScreen ? 'none' : 'block',
                        }}>
                        <MenuIcon />
                    </IconButton>}
                    {<Drawer
                        //from which side the drawer slides in
                        anchor="right"
                        //if open is true --> drawer is shown
                        open={open}
                        //function that is called when the drawer should close
                        onClose={toggleDrawer(false)}
                    //function that is called when the drawer should open
                    >
                        {/* The inside of the drawer */}
                        <Box
                            sx={{
                                p: 2,
                                height: 1,
                                backgroundColor: "#ffffff"
                            }}
                        >
                            {/* when clicking the icon it calls the function toggleDrawer and closes the drawer by setting the variable open to false */}
                            <IconButton onClick={toggleDrawer(false)} sx={{ mb: 2 }}>
                                <CloseIcon />
                            </IconButton>

                            <Divider sx={{ mb: 2 }} />

                            <Box sx={{ mb: 2 }}>
                                <ListItemButton to="/admin/public-dest/view" component={Link}>
                                    <ListItemText primary="Public Destinations" />
                                </ListItemButton>

                                <ListItemButton to="/admin/public-dest/add" component={Link}>
                                    <ListItemText primary="Add Public Destination" />
                                </ListItemButton>
                            </Box>
                        </Box>
                    </Drawer>}
                </Toolbar>
            </AppBar>
        </Box >
    )
}